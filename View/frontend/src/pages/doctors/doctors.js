import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './doctors.css';
import { useNavigate } from 'react-router-dom';

function Doctors() {
    const navigate = useNavigate();
    const [doctors, setDoctors] = useState([]); // Состояние для хранения данных о врачах

    useEffect(() => {
        // Выполнить запрос при монтировании компонента
        axios.get('https://localhost:7172/api/Doctors')
            .then(response => {
                // Установить данные о врачах после успешного запроса
                setDoctors(response.data); // Обновляем состояние с данными
            })
            .catch(error => {
                // Обработать ошибку, если запрос не удался
                console.error("Ошибка при получении данных о врачах:", error);
            });
    }, []);

    return (
        <div className="master-doctor">
            <div className="filters">
                <p className="filt">Фільтр</p>
                <ul className="many">
                    <li>
                        <button className='filt-btn'>Стать</button>
                    </li>
                    <li>
                        <button className='filt-btn'>Стаж</button>
                    </li>
                    <li>
                        <button className='filt-btn'>Спеціалізація</button>
                    </li>
                    <li>
                        <button className='filt-btn'>Оцінка</button>
                    </li>
                </ul>
                <div className="cards">
                    <div className="doctor-photo-cards">
                        <img className="ded" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
                        <h3 className="name">
                            Гена Цидрусні
                            <p className="specail-card">
                                Стоматолог
                            </p>
                        </h3>
                        <h4 className='exp'>
                            Працює понад 15 років
                        </h4>
                        <div className="info">
                            Лікар Ванечка Петров - досвідчений лікар, який провчився на дистанційці і без проблем зможе
                            вас вбити.
                        </div>
                        <button className="more_info" onClick={() => navigate("/appointment")}>Дізнатись</button>
                    </div>
                </div>
                <div className="cards">
                    {doctors.map(doctor => (
                        <div className="doctor-photo-cards" key={doctor.id}>
                            <img className="ded"
                                 src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
                            <h3 className="name">
                                {doctor.firstName}
                                <p className="specail-card">
                                    {doctor.secondName}
                                </p>
                            </h3>
                            <h4 className='exp'>
                                Працює понад {doctor.phone} років
                            </h4>
                            <div className="info">
                                {doctor.description}
                            </div>
                            <button className="more_info" onClick={() => navigate("/appointment")}>Дізнатись</button>
                        </div>
                    ))}
                </div>
                <div className="cards">
                    <div className="doctor-photo-cards">
                        <img className="ded" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
                        <h3 className="name">
                            Степан Бандерович
                            <p className="specail-card">
                                Стоматолог
                            </p>
                        </h3>
                        <h4 className='exp'>
                            Працює понад 15 років
                        </h4>
                        <div className="info">
                            Лікар Ванечка Петров - досвідчений лікар, який провчився на дистанційці і без проблем зможе
                            вас вбити.
                        </div>
                        <button className="more_info" onClick={() => navigate("/appointment")}>Дізнатись</button>
                    </div>
                </div>
            </div>

        </div>
    );
}
export default Doctors;
