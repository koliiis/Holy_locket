import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './doctors.css';
import { useNavigate } from 'react-router-dom';



function Doctors() {
    const navigate = useNavigate();
    const [doctors, setDoctors] = useState([]);
    const [specialities, setSpecialities] = useState({});

    useEffect(() => {
        axios.get('https://localhost:7172/api/Doctors')
            .then(response => {
                setDoctors(response.data);
            })
            .catch(error => {
                console.error("шибка при получении данных о врачах:", error);
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

    const handleNavigateToAppointment = (doctor) => {
        navigate('/appointment', { state: { doctor } });
    };

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

                {doctors.map(doctor => (
                    <div className="card-container" key={doctor.id}>
                        <div className="cards">
                            <img className="ded" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
                            <h3 className="name">
                                {doctor.firstName} {doctor.secondName}
                                <p className="specail-card">
                                    {specialities[doctor.specialityId]?.name || "Специальность не найдена"}
                                </p>
                            </h3>
                            <h4 className='exp'>
                                Працює понад {doctor.experience} років
                            </h4>
                            <div className="info">
                                {doctor.description}
                            </div>
                            <button className="more_info" onClick={() => handleNavigateToAppointment(doctor)}>Дізнатись</button>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
}
export default Doctors;