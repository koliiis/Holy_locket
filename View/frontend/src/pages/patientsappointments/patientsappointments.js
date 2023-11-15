import React, { useState, useEffect } from 'react';
import axios from 'axios';
import "./patientsappointments.css";
import { useNavigate } from 'react-router-dom';

function Patientsappointments() {
    const navigate = useNavigate();
    const [doctors, setDoctors] = useState([]);
    const [specialities, setSpecialities] = useState({});


    useEffect(() => {
        axios.get('https://localhost:7172/api/Doctors')
            .then(response => {
                setDoctors(response.data);
            })
            .catch(error => {
                console.error("Ошибка при получении данных о врачах:", error);
            });

            axios.get('https://localhost:7172/api/Speciality')
            .then(response => {
                const specialitiesData = {};
                response.data.forEach(speciality => {
                    specialitiesData[speciality.id] = speciality;
                });
                setSpecialities(specialitiesData);
            })
            .catch(error => {
                console.error("Ошибка при получении данных о специальностях:", error);
            });
    }, []);

    return (
    <div className="body1">

        {doctors.map(doctor => (
            <div className="div1">
                <h2 className="h21">{doctor.firstName} {doctor.secondName}</h2>
                <p className="p1">{specialities[doctor.specialityId]?.name || "Специальность не найдена"}</p>
                <h3 className="h31">Стан запису:</h3>
                <div className="div21">ЗАКІНЧЕНО</div>
                <button className="div3" onClick={() => navigate("/doctors")}>Записатися ще раз</button>
                <h3 className="appdet">Деталі прийому:</h3>
                <div className="div4">
                    <p className="p1">Дата: 6.11.2023</p>
                    <p className="p1">Час: 14:00</p>
                    <p className="p1">Кабінет: 418</p>
                </div>
        <img className="div5" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
        </div>
        ))}

    </div>

    
    );
}

export default Patientsappointments;