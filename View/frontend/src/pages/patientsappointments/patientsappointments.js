import React, { useState, useEffect } from 'react';
import axios from 'axios';
import "./patientsappointments.css";
import { useNavigate } from 'react-router-dom';

function Patientsappointments() {
    const navigate = useNavigate();
    const [InfoApp, setInfoApp] = useState([]);

    useEffect(() => {
        axios.get('https://localhost:7172/api/Appointment/InfoPatient?id=1')
            .then(response => {
                setInfoApp(response.data);
            })
            .catch(error => {
                console.error("Помилка при отриманні даних:", error);
            });
    }, []);

    const handleCance = (id) => {
        axios.delete(`https://localhost:7172/api/Appointment/SoftDelete?id=${id}`, {id:id})
            .then((response) => {
                console.log("Peremoga");
            })
            .catch((error) => {
                console.error('Ошибка при отправке данных:', error);
            });
    }

    return (
        <div className="body1">
            {InfoApp.map(infapp => (
                <div className="div1" key={infapp.id}>
                    <h2 className="h21">{infapp.doctorName} {infapp.doctorSecondName}</h2>
                    <p className="p1">{infapp.specialityName}</p>
                    <h3 className="h31">Стан запису:</h3>
                    <div className="div21">{infapp.inactive ? 'Cancel' : 'In action'}</div>
                    <button className="div3" onClick={() => navigate("/doctors")}>Записатися ще раз</button>
                    <button className="cancel-btn" onClick={() => handleCance(infapp.id)}>Відмінити запис</button>
                    <h3 className="appdet">Деталі прийому:</h3>
                    <div className="div4">
                        <p className="p1">Дата: {infapp.date}</p>
                        <p className="p1">Час: {infapp.time}</p>
                        <p className="p1">Кабінет: {infapp.hospitalId}</p>
                    </div>
                    <img className="div5" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg" alt={`Doctor ${infapp.doctorName}`} />
                </div>
            ))}
        </div>
    );
}

export default Patientsappointments;