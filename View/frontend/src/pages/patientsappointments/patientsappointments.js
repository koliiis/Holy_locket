import React, { useState, useEffect } from 'react';
import "./patientsappointments.css";

function patientsappointments() {
   return (
    <div className="body1">
        <div className="div1">
            <h2 className="h21">Костя Пивопив</h2>
            <p className="p1">Акушер-гінеколог</p>
            <h3 className="h31">Стан запису:</h3>
            <div className="div21">ЗАКІНЧЕНО</div>
            <div className="div3">Записатися ще раз</div>
            <h3 className="appdet">Деталі прийому:</h3>
            <div className="div4">
                <p className="p1">Дата: 6.11.2023</p>
                <p className="p1">Час: 14:00</p>
                <p className="p1">Адреса: вул. Михайла Брайчевського, 8</p>
                <p className="p1">Кабінет: 418</p>
            </div>
        </div>
        <img className="div5" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
        <div class="div1">
            <h2 className="h211">Валєра Непив</h2>
            <p className="p1">Уролог</p>
            <h3 className="h31">Стан запису:</h3>
            <div class="div2">ПІДТВЕРДЖЕНО</div>
            <div class="div3">Записатися ще раз</div>
            <h3 class="appdet">Деталі прийому:</h3>
            <div class="div4">
                <p className="p1">Дата: 10.11.2023</p>
                <p className="p1">Час: 11:00</p>
                <p className="p1">Адреса: вул. Академіка Янгеля, 7</p>
                <p className="p1">Кабінет: 105</p>
            </div>
        </div>
        <img className="div5" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
        <div class="div1">
            <h2 className="h211">Валєра Непив</h2>
            <p className="p1">Уролог</p>
            <h3 className="h31">Стан запису:</h3>
            <div class="div2">ПІДТВЕРДЖЕНО</div>
            <div class="div3">Записатися ще раз</div>
            <h3 class="appdet">Деталі прийому:</h3>
            <div class="div4">
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

export default patientsappointments;