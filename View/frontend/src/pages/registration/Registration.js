import React, { useState } from 'react';
import './Registration.scss';
import axios from "axios";
import Modal_Appointment from "../../component/modal-appointment";

function Registration() {
    const [modalSuccessActive, setModalSuccessActive] = useState(false);
    const [modalErrorActive, setModalErrorActive] = useState(false);
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');

    const validateEmail = (email) => {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
      };

    const handleSubmit = (e) => {
        e.preventDefault();

        let hasErrors = false;
        let hasResponse = false;

        if (name.length < 2 || name.length > 15) {
            setError('Неправильно введено ім`я');
            hasErrors = true;
        } else if (surname.length < 7 || surname.length > 20) {
            setError('Неправильно введено прізвище');
            hasErrors = true;
        } else if (phoneNumber.length < 6) {
            setError('Неправильно введено телефон');
            hasErrors = true;
        } else if (!validateEmail(email)) {
            setError('Неправильно введений email');
            hasErrors = true;
        } else if (password.length < 5) {
            setError('Пароль має бути як мінімум 6 знаків!');
            hasErrors = true;
        } else {
            setError('');
            hasResponse = true;
        }

          if (hasErrors) {
            setModalErrorActive(true);
            return;
          }

        axios.post('https://localhost:7172/api/Patient', {
            firstName: name,
            secondName: surname,
            phone: phoneNumber,
            email: email,
            password: password,
        })

        .then((response) => {
            console.log("Peremoga");
            setModalSuccessActive(true);
        })
        .catch((error) => {
            console.error('Ошибка при отправке данных:', error);
        });
    }

    return (
        <div className="container mx-auto cont">
            <form action="#" method="POST"  onSubmit={handleSubmit}>
                <div className="master_2">
                    <h2 className="header_regist">Реєстрація</h2>
                    <div className="inputее">
                        <div className="input-box">
                            <input
                                className="form-control mx-auto my-3 reg_inpt"
                                required="required"
                                type="text"
                                name="username"
                                value={name}
                                onChange={(e) => setName(e.target.value)}
                            />
                            <span>Username</span>
                            <i></i>
                        </div>

                        <div className="input-box">
                            <input
                                className="form-control mx-auto my-3 reg_inpt"
                                required="required"
                                type="text"
                                name="surname"
                                value={surname}
                                onChange={(e) => setSurname(e.target.value)}
                            />
                            <span>Прізвище</span>
                            <i></i>
                        </div>

                        <div className="input-box">
                            <input
                                className="form-control mx-auto my-3 reg_inpt"
                                required="required"
                                type="tel"
                                name="usernumber"
                                value={phoneNumber}
                                onChange={(e) => setPhoneNumber(e.target.value)}
                            />
                            <span>Phone number</span>
                            <i></i>
                        </div>

                        <div className="input-box">
                            <input
                                className="form-control mx-auto my-3 reg_inpt"
                                required="required"
                                type="text"
                                name="useremail"
                                value={email}
                                onChange={(e) => setEmail(e.target.value)}
                            />
                            <span>Електронна пошта</span>
                            <i></i>
                        </div>

                        <div className="input-box">
                            <input
                                className="form-control mx-auto my-3 reg_inpt"
                                required="required"
                                type="password"
                                name="useremail"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                            />
                            <span>Пароль</span>
                            <i></i>
                        </div>
                    </div>

                    <div className="md-mx-auto btn-reg">
                        <button className='button_reg' type="submit">Зареєструватися</button>
                    </div>
                    <div className='footer_reg'>
                        Вже маєте зареєстрований акаунт? <a className="link_login" href="/login">Вхід в акаунт</a>
                    </div>
                </div>
            </form>

            {modalSuccessActive && (
                <Modal_Appointment
                    active={modalSuccessActive}
                    setActive={() => setModalSuccessActive(false)}>
                <div>
                    <div>
                        <h3 className='suc'>Успішна реєстрація!!</h3>
                    </div>
                    <div>
                        <p>
                            <button className="confirm" type="submit" onClick={() => setModalSuccessActive(false)}>Підтвердити</button>
                        </p>
                    </div>
                </div>
                </Modal_Appointment>
            )}

            {modalErrorActive && (
                <Modal_Appointment
                    active={modalErrorActive}
                    setActive={() => setModalErrorActive(false)}>
                <div>
                    <div>
                        <h3>При заповненні форми виникли помилки:</h3>
                        <ul className='qwe'>
                            {error && <li>{error}</li>}
                        </ul>
                    </div>
                    <div>
                        <p>
                            <button className="confirm" type="submit" onClick={() => setModalErrorActive(false)}>Підтвердити</button>
                        </p>
                    </div>
                </div>
                </Modal_Appointment>
            )}
        </div>
    );
}

export default Registration;