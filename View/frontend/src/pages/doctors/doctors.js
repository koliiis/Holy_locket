import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './doctors.scss';
import { useNavigate } from 'react-router-dom';

function truncateText(text, maxLength) {
    if (text.length <= maxLength) {
        return text;
    } else {
        const truncatedText = text.substring(0, maxLength);
        const lastSpaceIndex = truncatedText.lastIndexOf(' ');
        return truncatedText.substring(0, lastSpaceIndex) + '...';
    }
}

function Doctors() {
    const navigate = useNavigate();
    const [doctors, setDoctors] = useState([]);
    const [selectedSpecialization, setSelectedSpecialization] = useState(null);
    const [selectedExperience, setSelectedExperience] = useState(null);
    const [selectedGender, setSelectedGender] = useState(null);

    const fetchDoctors = (spec, exp = 0, gen) => {
        console.log(spec, exp, gen)
        exp = exp === null ? 0 : exp;
        axios.get(`https://localhost:7172/api/Doctors?minimumExpirience=${exp}&specialityId=0&gender=`)
            .then(response => {
                setDoctors(response.data);
            })
            .catch(error => {
                console.error("Ошибка при получении данных о врачах:", error);
            });
    };

    useEffect(() => {
        // Вызов функции при загрузке компонента
        fetchDoctors(selectedSpecialization, selectedExperience, selectedGender);
    }, [selectedSpecialization, selectedExperience, selectedGender]);

    const handleNavigateToAppointment = (doctor) => {
        navigate('/appointment', { state: { doctor } });
    };

    const years_exp = [1, 3, 5, 7, 9, 12, 15];

    const handleSelect = (value, type) => {
        const handlers = {
            specialization: setSelectedSpecialization,
            experience: setSelectedExperience,
            gender: setSelectedGender
        };

        const handler = handlers[type];

        if (handler) {
            handler(value);
        }
    };

    const handleConfirmFilter = () => {
        fetchDoctors(selectedSpecialization, selectedExperience, selectedGender);
    };

    return (
        <div className="row container-fluid justify-content-center master-doctor" aria-expanded='md'>
            <div className="filters">
                <p className="filt">Фільтр</p>
                <ul className="many">
                    <li>
                        <div className="dropdown filt-btn">
                            <a
                                className="btn btn-secondary dropdown-toggle"
                                role="button"
                                id="specializationDropdown"
                                data-bs-toggle="dropdown"
                            >
                                {selectedSpecialization || 'Спеціалізація'}
                            </a>
                            <ul className="dropdown-menu" aria-labelledby="specializationDropdown">
                                <li><a className="dropdown-item" onClick={() => handleSelect('Action', 'specialization')}>Action</a><br/></li>
                                <li><a className="dropdown-item" onClick={() => handleSelect('Another action', 'specialization')}>Another action</a><br/></li>
                                <li><a className="dropdown-item" onClick={() => handleSelect('Something else here', 'specialization')}>Something else here</a><br/></li>
                            </ul>
                        </div>
                    </li>
                    <li>
                        <div className="dropdown filt-btn">
                            <a
                                className="btn btn-secondary dropdown-toggle"
                                role="button"
                                id="experienceDropdown"
                                data-bs-toggle="dropdown"
                            >
                                {selectedExperience === null ? 'Стаж' : selectedExperience + "+ років досвіду"}
                            </a>
                            <ul className="dropdown-menu" aria-labelledby="experienceDropdown">
                                {years_exp.map(year => (
                                    <li key={year}>
                                        <a
                                            className="dropdown-item"
                                            onClick={() => handleSelect(year, 'experience')}
                                        >
                                            {year}+ років досвіду
                                        </a>
                                        <br/>
                                    </li>
                                ))}
                            </ul>
                        </div>
                    </li>
                    <li>
                        <div className="dropdown filt-btn">
                            <a
                                className="btn btn-secondary dropdown-toggle"
                                role="button"
                                id="genderDropdown"
                                data-bs-toggle="dropdown"
                            >
                                {selectedGender || 'Стать'}
                            </a>
                            <ul className="dropdown-menu" aria-labelledby="genderDropdown">
                                <li><a className="dropdown-item" onClick={() => handleSelect('Чоловік', 'gender')}>Чоловік</a><br/></li>
                                <li><a className="dropdown-item" onClick={() => handleSelect('Жінка', 'gender')}>Жінка</a><br/></li>
                            </ul>
                        </div>
                    </li>
                    <li>
                        <button className='filt-btn'>Оцінка</button>
                    </li>
                    <button className="confirm_filt" onClick={handleConfirmFilter}>Підтвердити</button>
                </ul>
            </div>
            <div className="col-xxl-10 col-md-8 roww">
                <div className="row justify-content-center card-container">
                    {doctors.map(doctor => (
                        <div className="cards" key={doctor.id}>
                            <div className="block">
                                <img className="ded"
                                     src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
                                <h3 className="name">
                                    {doctor.firstName} {doctor.secondName}
                                    <p className="specail-card">
                                        {doctor.specialityName}
                                    </p>
                                </h3>
                                <h4 className='exp'>
                                    Працює понад {doctor.experience} років
                                </h4>
                                <div className="info">
                                    {truncateText(doctor.description, 100)}
                                </div>
                            </div>
                            <button className="more_info" onClick={() => handleNavigateToAppointment(doctor)}>Дізнатись</button>
                        </div>
                    ))}
                </div>
            </div>
        </div>
    );
}

export default Doctors;
