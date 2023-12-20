import React, { useState, useEffect } from 'react';
import axios from 'axios';
import "./patientprofile.scss";
import { useNavigate } from 'react-router-dom';
import Modal_Appointment from "../../component/modal-appointment";

import img3 from './img3.png';
import img4 from './img4.png';
import img5 from './img5.png';
import img6 from './img6.png';
import img7 from './img7.png';
import img8 from './img8.png';
import img9 from './img9.png';

function Patientprofile() {
    const [infoPage, setInfoPage] = useState([]);
    const navigate = useNavigate();
    const [modalActiveChangeInfo, setModalActiveChangeInfo] = useState(false);
    const [modalSuccessActive, setModalSuccessActive] = useState(false);
    const [modalErrorActive, setModalErrorActive] = useState(false);

    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');


    const jwtToken = sessionStorage.getItem('jwtToken');

    useEffect(() => {
        axios.get(`https://localhost:7172/api/Patient/UserPatient/${jwtToken}`)
            .then(response => {
                setInfoPage(response.data);
                console.log(response.data);
            })
            .catch(error => {
                console.error("Помилка при отриманні даних:", error);
                if (error.response.status === 401) {
                    sessionStorage.removeItem('jwtToken');
                    navigate("/login");
                }
            });
    }, []);

    const handleChangeInfo = () => {
        setModalActiveChangeInfo(true);
    };

    return (
        <div className="body11">
            <img className="img11" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
            <h2 className="h22">{infoPage.firstName} {infoPage.secondName}</h2>
                <img className="img33" src={img3} onClick={() => handleChangeInfo()}/>
            <div className='div11'>
                <p className='p11'>Чоловік</p>
                <img className="img44" src={img5}/>
            </div>
            <div className='div22'>
                <p className='p11'>{infoPage.birthday}</p>
                <img className="img44" src={img4}/>
            </div>
            <div className='div22'>
                <p className='p11'>{infoPage.email}</p>
                <img className="img44" src={img6}/>
            </div>
            <div className='div33'>
                <p className='p11'>Україна, Київ</p>
                <img className="img44" src={img7}/>
            </div>
            <div className='div44'>
                <p className='p11'>{infoPage.phone}</p>
                <img className="img44" src={img8}/>
            </div>
            <div className='div44'>
                <p className='p11'>1234567890</p>
                <img className="img44" src={img9}/>
            </div>

            {modalActiveChangeInfo && (
                <Modal_Appointment
                    active={modalActiveChangeInfo}
                    setActive={() => setModalActiveChangeInfo(false)}
                >
                    <h3>
                        <p className="confirm-text">
                            Введіть данні, які ви хочете змінити
                        </p>

                            <input
                                className="form-control mx-auto my-3 reg_inpt"

                                type="text"
                                name="username"
                                placeholder="Ім'я"
                                value={name}
                                onChange={(e) => setName(e.target.value)}
                            />

                            <input
                                className="form-control mx-auto my-3 reg_inpt"
                                placeholder="Прізвище"
                                type="text"
                                name="surname"
                                value={surname}
                                onChange={(e) => setSurname(e.target.value)}
                            />

                            <input
                                className="form-control mx-auto my-3 reg_inpt"
                                placeholder="Номер телефон"
                                type="tel"
                                name="usernumber"
                                value={phoneNumber}
                                onChange={(e) => setPhoneNumber(e.target.value)}
                            />

                            <input
                                className="form-control mx-auto my-3 reg_inpt"
                                placeholder="Електронна пошта"
                                type="text"
                                name="useremail"
                                value={email}
                                onChange={(e) => setEmail(e.target.value)}
                            />

                            <input
                                className="form-control mx-auto my-3 reg_inpt"
                                placeholder="Пароль"
                                type="password"
                                name="useremail"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                            />
                        <div>
                            <form action="#" method="POST">
                                <button className="confirm" type="submit">
                                    Підтвердити
                                </button>
                            </form>
                        </div>
                    </h3>
                </Modal_Appointment>
            )}
        </div>
    );
}

export default Patientprofile;
