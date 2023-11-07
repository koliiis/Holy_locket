import React, { useState, useEffect } from 'react';
import "./patientsappointments.css";
import { useNavigate } from 'react-router-dom';

function Patientsappointments() {
    const navigate = useNavigate();

    return (
    <div className="body1">
        <div className="div1">
            <h2 className="h21">Костя Пивопив</h2>
            <p className="p1">Акушер-гінеколог</p>
            <h3 className="h31">Стан запису:</h3>
            <div className="div21">ЗАКІНЧЕНО</div>
            <button className="div3" onClick={() => navigate("/appointment")}>Записатися ще раз</button>
            <h3 className="appdet">Деталі прийому:</h3>
            <div className="div4">
                <p className="p1">Дата: 6.11.2023</p>
                <p className="p1">Час: 14:00</p>
                <p className="p1">Адреса: вул. Михайла Брайчевського, 8</p>
                <p className="p1">Кабінет: 418</p>
            </div>
        </div>
        <img className="div5" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
        <div className="div1">
            <h2 className="h211">Валєра Непив</h2>
            <p className="p1">Уролог</p>
            <h3 className="h31">Стан запису:</h3>
            <div className="div2">ПІДТВЕРДЖЕНО</div>
            <button className="div3" onClick={() => navigate("/appointment")}>Записатися ще раз</button>
            <h3 className="appdet">Деталі прийому:</h3>
            <div className="div4">
                <p className="p1">Дата: 10.11.2023</p>
                <p className="p1">Час: 11:00</p>
                <p className="p1">Адреса: вул. Академіка Янгеля, 7</p>
                <p className="p1">Кабінет: 105</p>
            </div>
        </div>
        <img className="div5" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
        <div className="div1">
            <h2 className="h211">Валєра Непив</h2>
            <p className="p1">Уролог</p>
            <h3 className="h31">Стан запису:</h3>
            <div className="div2">ПІДТВЕРДЖЕНО</div>
            <button className="div3" onClick={() => navigate("/appointment")}>Записатися ще раз</button>
            <h3 className="appdet">Деталі прийому:</h3>
            <div className="div4">
                <p className="p1">Дата: 10.11.2023</p>
                <p className="p1">Час: 11:00</p>
                <p className="p1">Адреса: вул. Академіка Янгеля, 7</p>
                <p className="p1">Кабінет: 105</p>
            </div>
        </div>
        <img className="div5" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
    </div>
   );
}

export default Patientsappointments;