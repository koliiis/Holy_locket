import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './patientsappointments.scss';
import { useNavigate } from 'react-router-dom';
import Modal_Appointment from "../../component/modal-appointment";

function PatientsAppointments() {
    const navigate = useNavigate();
    const [infoApp, setInfoApp] = useState([]);
    const [modalActiveAppointment, setodalActiveAppointment] = useState(false);
    const [currentInfapp, setCurrentInfapp] = useState(null);

    const [rating, setRating] = useState(null);

    const jwtToken = sessionStorage.getItem('jwtToken');
    console.log(jwtToken);

    const handleRatingChange = (event) => {
        setRating(event.target.value);
        axios.post(`https://localhost:7172/api/Rating/${jwtToken}`, {
            doctorId: currentInfapp.id,
            rate: rating
        })

            .then((response) => {
                console.log("Peremoga");
            })
            .catch((error) => {
                console.error('Ошибка при отправке данных:', error);
            });
        }

    useEffect(() => {

        axios.get(`https://localhost:7172/api/Appointment/InfoPatient/${jwtToken}`)
            .then(response => {
                setInfoApp(response.data);

            })
            .catch(error => {
                console.error('Помилка при отриманні даних:', error);
                if (error.response.status === 401) {
                    sessionStorage.removeItem('jwtToken');
                    navigate("/login");
                }
            });
    });

    const handleCancel = (id) => {
        axios.delete(`https://localhost:7172/api/Appointment/SoftDelete?id=${id}`, { id })
            .then(() => {
                console.log('Peremoga');
            })
            .catch((error) => {
                console.error('Помилка при відправці даних:', error);
            });
        window.location.reload();
    }

    const handleTimeSelection = (infapp) => {
        setCurrentInfapp(infapp);
        setodalActiveAppointment(true);
    };

    return (
        <div className="body1">
            {infoApp.map((infapp) => (
                <div className="container-fluid div1" key={infapp.id}>
                    <h2 className="fw-bold h21">{infapp.doctorName} {infapp.doctorSecondName}</h2>
                    <p className="p1">{infapp.specialityName}</p>
                    <h3 className="h31">Стан запису:</h3>
                    <div className="div21">{infapp.inactive ? 'Canceled' : infapp.irrelevant ? 'Irrelevant' : 'In action'}</div>
                    <button className="div3" onClick={() => navigate("/doctors")}>Записатися ще раз</button>
                    {!infapp.inactive && !infapp.irrelevant && (
                        <button className="cancel-btn" onClick={() => handleCancel(infapp.id)}>Відмінити запис</button>
                    )}
                    {!infapp.inactive && infapp.irrelevant && (
                        <button className="rating-btn" onClick={() => handleTimeSelection(infapp)}>Оцінити лікаря</button>
                    )}
                    <h3 className="appdet">Деталі прийому:</h3>
                    <div className="div4">
                        <p className="p1">Дата: {infapp.date}</p>
                        <p className="p1">Час: {infapp.time}</p>
                        <p className="p1">Кабінет: {infapp.hospitalId}</p>
                    </div>
                    <img className="div5" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
                </div>
            ))}

            {modalActiveAppointment && currentInfapp && (
                <Modal_Appointment
                    active={modalActiveAppointment}
                    setActive={() => {
                        setodalActiveAppointment(false);
                        setCurrentInfapp(null);
                    }}
                >
                    <h3>
                        <p className="confirm-text">
                            Оцініть якість послуг (від 1 до 5), які вам надал лікар {currentInfapp.doctorName} {currentInfapp.doctorSecondName} на {currentInfapp.time}
                        </p>
                        <div className="rating-area">
                            <input type="radio" id="star-5" name="rating" value="5" onChange={handleRatingChange}/>
                            <label htmlFor="star-5" title="Оценка «5»"></label>

                            <input type="radio" id="star-4" name="rating" value="4" onChange={handleRatingChange}/>
                            <label htmlFor="star-4" title="Оценка «4»"></label>

                            <input type="radio" id="star-3" name="rating" value="3" onChange={handleRatingChange}/>
                            <label htmlFor="star-3" title="Оценка «3»"></label>

                            <input type="radio" id="star-2" name="rating" value="2" onChange={handleRatingChange}/>
                            <label htmlFor="star-2" title="Оценка «2»"></label>

                            <input type="radio" id="star-1" name="rating" value="1" onChange={handleRatingChange}/>
                            <label htmlFor="star-1" title="Оценка «1»"></label>

                            <p>Выбранная оценка: {rating}</p>
                        </div>
                        <div>
                            <form action="#" method="POST" onSubmit={() => handleTimeSelection(currentInfapp)}>
                                <button className="confirm" type="submit">Підтвердити</button>
                            </form>
                        </div>
                    </h3>
                </Modal_Appointment>
            )}
        </div>
    );
}

export default PatientsAppointments;
