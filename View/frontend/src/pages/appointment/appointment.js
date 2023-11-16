import React, { useEffect, useState } from 'react';
import "./appointment.css";
import { useLocation } from 'react-router-dom';
import axios from "axios";
import Modal_Appointment from "../../component/modal-appointment";

const Appointment = () => {
    const currentDay = new Date();
    const indexDayOfWeek = currentDay.getDay();
    const daysOfWeek = ["НЕДІЛЯ", 'ПОНЕДІЛОК', 'ВІВТОРОК', 'СЕРЕДА', 'ЧЕТВЕР', "П'ЯТНИЦЯ", "CУБОТА"];
    const firstPartOfWeek = daysOfWeek.slice(indexDayOfWeek);
    const secondPartOfWeek = daysOfWeek.slice(0, indexDayOfWeek);
    const WorkWeek = [...firstPartOfWeek, ...secondPartOfWeek];


    const dateObj = new Date();
    const currentDayIndex = dateObj.getDay();
    const currentDate = dateObj.getDate() - currentDayIndex + 4; // Текущая дата минус день недели плюс 1
    const dateArray = [];

    for (let i = 0; i < 7; i++) {  // Изменено с 7 на 5
        const newDate = new Date();
        newDate.setDate(currentDate + i);
        dateArray.push(newDate);
    }

    const [specialities, setSpecialities] = useState({});
    const location = useLocation();
    const { doctor } = location.state;
    const [modalActive, setModalActive] = useState(false);
    const [selectedTime, setSelectedTime] = useState('');
    const [selectedDay, setSelectedDay] = useState('');

    var iteration = 0;
    var time_slot = '';
    const startTime = 10;
    const endTime = 18;
    const timeSlots = [];

    for (let hour = startTime; hour <= endTime; hour++) {
        for (let minute = 0; minute < 60; minute += 30) {
            const time = `${hour.toString().padStart(2, '0')}:${minute.toString().padStart(2, '0')}`;
            iteration += 1;
            if (iteration === 2) {
                time_slot = `${time_slot}-${time}`;
                timeSlots.push(time_slot);
                time_slot = time;
                iteration -= 1;
            } else time_slot += time;
        }
    }

    const renderTimeSlots = () => {
        return (
            <>
                <tr>
                    {WorkWeek.map((day, dayIndex) => (
                        <th key={dayIndex}>
                            {day}
                            <br />
                            {dateArray[dayIndex] && dateArray[dayIndex].toLocaleDateString('uk-UA')}
                        </th>
                    ))}
                </tr>

                {timeSlots.map((time, timeIndex) => (
                    <tr key={timeIndex}>

                        {WorkWeek.map((day, dayIndex) => (
                            <td key={dayIndex}>
                                <button className="time-btn" onClick={() => handleTimeSelection(time, day, dateArray[dayIndex])}>
                                    {time}
                                </button>
                            </td>
                        ))}
                    </tr>
                ))}
            </>
        );
    };

    const handleTimeSelection = (time, day, date) => {
        setSelectedTime(time);
        setSelectedDay(`${date.getDate()}.${date.getMonth() + 1}.${date.getFullYear()}`);
        setModalActive(true);
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
                        <p>{specialities[doctor.specialityId]?.name || "Специальность не найдена"}</p>
                    </h2>
                    <h3>Про лікаря:</h3>
                    <p>Стать: {doctor.gender}</p>
                    <p>Стаж: {doctor.experience}</p>
                    <p>{doctor.description} </p>
                </div>
            </div>
            <table>
                <p className="head">Записатись на прийом:</p>
                <thead>
                {renderTimeSlots()}
                </thead>
            </table>

            {modalActive && (
                <Modal_Appointment
                    active={modalActive}
                    setActive={() => setModalActive(false)}
                    time={selectedTime}
                    day={selectedDay}>
                    <h3>
                        <p>
                            Ви впевненні, що хочете записатися до лікаря <span>{doctor.firstName} {doctor.secondName} </span>
                            на {selectedDay} о {selectedTime}?
                        </p>
                        <div>
                            <button className="confirm">Підтвердити</button>
                        </div>
                    </h3>
                </Modal_Appointment>
            )}
        </div>
    );
};

export default Appointment;
