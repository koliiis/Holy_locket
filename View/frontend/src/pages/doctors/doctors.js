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

    useEffect(() => {
        axios.get('https://localhost:7172/api/Doctors')
            .then(response => {
                setDoctors(response.data);
            })
            .catch(error => {
                console.error("Ошибка при получении данных о врачах:", error);
            });

    }, []);

    const handleNavigateToAppointment = (doctor) => {
        navigate('/appointment', { state: { doctor } });
    };

    const [selectedValue, setSelectedValue] = useState(null);

    const handleSelect = (value) => {
        setSelectedValue(value);
    };

    return (
        <div className="row container-fluid justify-content-center master-doctor" aria-expanded='md'>
            <div className="filters">
                <p className="filt">Фільтр</p>

                <ul className="many">
                    <li>
                        <div className="dropdown filt-btn">
                            <a className="btn btn-secondary dropdown-toggle" href="#" role="button"
                               id="dropdownMenuLink" data-bs-toggle="dropdown" aria-expanded="false">
                                {selectedValue || 'Спеціалізація'}
                            </a>

                            <ul className="dropdown-menu" aria-labelledby="dropdownMenuLink">
                                <li><a className="dropdown-item" onClick={() => handleSelect('Action')}>Action</a></li>
                                <br/>
                                <li><a className="dropdown-item" onClick={() => handleSelect('Another action')}>Another
                                    action</a></li>
                                <br/>
                                <li><a className="dropdown-item" onClick={() => handleSelect('Something else here')}>Something
                                    else here</a></li>
                                <br/>
                            </ul>
                        </div>
                    </li>
                    <li>
                        <button className='filt-btn'>Стать</button>
                    </li>
                    <li>
                        <button className='filt-btn'>Стаж</button>
                    </li>
                    <li>
                        <button className='filt-btn'>Оцінка</button>
                    </li>
                </ul>
            </div>
            <div className="col-xxl-10 col-md-8 roww">
                <div className="row justify-content-center card-container">
                    {doctors.map(doctor => (
                        <div className="cards" key={doctor.id}>
                        <div className="block">
                                    <img className="ded" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
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