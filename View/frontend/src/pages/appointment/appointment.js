import React, {useEffect, useState} from 'react';
import "./appointment.css";
import { useLocation } from 'react-router-dom';
import axios from "axios";

const Appointment = () => {
    const daysOfWeek = ['ПОНЕДІЛОК', 'ВІВТОРОК', 'СЕРЕДА', 'ЧЕТВЕР', "П'ЯТНИЦЯ"];
    const startTime = 10;
    const endTime = 18;
    const timeSlots = [];
    const [specialities, setSpecialities] = useState({});
    const location = useLocation();
    const { doctor } = location.state;

    var iteration = 0;
    var time_slot = '';
    for (let hour = startTime; hour <= endTime; hour++) {
        for (let minute = 0; minute < 60; minute += 30) {
            const time = `${hour.toString().padStart(2, '0')}:${minute.toString().padStart(2, '0')}`;
            iteration += 1;
            if (iteration === 2) {
                time_slot = `${time_slot}-${time}`;
                timeSlots.push(time_slot);
                time_slot = time;
                iteration -= 1;
            }
            else time_slot += time;
        }
    }

    const renderTimeSlots = () => {
        return timeSlots.map((time) => (
            <tr key={time}>
                {daysOfWeek.map((day) => (
                    <td key={time}>
                        <button className="time-btn">{time}</button>
                    </td>
                ))}
            </tr>
        ));
    };

    useEffect(() => {
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
        <div className="appoint">
            <div className="doctors">
                <div className="doctor-photo">
                    <img className="appoint-photo" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"
                         alt={`${doctor.firstName} ${doctor.secondName}`}
                    />
                </div>
                <div className="doctor-info">
                    <h2 className="special">
                        {doctor.firstName} {doctor.secondName}
                        {specialities[doctor.specialityId]?.name || "Специальность не найдена"}
                    </h2>
                    <h3>Про лікаря:</h3>
                    <p>Стать: {doctor.gender}</p>
                    <p>Стаж: {doctor.experience}</p>
                    <p>{doctor.description}</p>
                </div>
            </div>
            <table>
                <p className="head">Записатись на прийом:</p>
                <thead>
                <tr className="days">
                    {daysOfWeek.map((day) => (
                        <th className='days-btn' key={day}>{day}</th>
                    ))}
                </tr>
                </thead>
                <tbody>
                {renderTimeSlots()}
                </tbody>
            </table>
        </div>
    );
};

export default Appointment;