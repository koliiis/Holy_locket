import React from 'react';
import './doctors.css';
import { useNavigate } from 'react-router-dom';

function Doctors() {
    const navigate = useNavigate();
    return (
        <div className="master-doctor">
            <div className="filters">
                <p className="filt">Фільтр</p>
                <ul className="many">
                    <li><button className='filt-btn'>Стать</button></li>
                    <li><button className='filt-btn'>Стаж</button></li>
                    <li><button className='filt-btn'>Спеціалізація</button></li>
                    <li><button className='filt-btn'>Оцінка</button></li>
                </ul>
                <div className="cards">
                    <div className="doctor-photo-cards">
                        <img className="ded" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
                        <h3 className="name">
                            Иван Петров
                            <p className="specail-card">
                                Стоматолог
                            </p>
                        </h3>
                        <h4 className='exp'>
                            Працює понад 15 років
                        </h4>
                        <div className="info">
                            Лікар Ванечка Петров - досвідчений лікар, який провчився на дистанційці і без проблем зможе вас вбити.
                        </div>
                        <button className="more_info" onClick={() => navigate("/appointment")}>Дізнатись</button>
                    </div>
                </div>
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
                            Лікар Ванечка Петров - досвідчений лікар, який провчився на дистанційці і без проблем зможе вас вбити.
                        </div>
                        <button className="more_info" onClick={() => navigate("/appointment")}>Дізнатись</button>
                    </div>
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
                            Лікар Ванечка Петров - досвідчений лікар, який провчився на дистанційці і без проблем зможе вас вбити.
                        </div>
                        <button className="more_info" onClick={() => navigate("/appointment")}>Дізнатись</button>
                    </div>
                </div>
            </div>

        </div>
    );
}

export default Doctors;
