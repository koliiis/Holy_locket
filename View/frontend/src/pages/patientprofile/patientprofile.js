import React, { useState, useEffect } from 'react';
import axios from 'axios';
import "./patientprofile.css";

import img2 from './img2.png';
import img3 from './img3.png';
import img4 from './img4.png';
import img5 from './img5.png';
import img6 from './img6.png';
import img7 from './img7.png';
import img8 from './img8.png';
import img9 from './img9.png';

function Patientprofile() {
    const [InfoPage, setInfoPage] = useState({});
    const [isEditing, setIsEditing] = useState(false);
    const [editedFirstName, setEditedFirstName] = useState('');
    const [editedSecondName, setEditedSecondName] = useState('');
    const [editedEmail, setEditedEmail] = useState('');
    const [editedDate, setEditedDate] = useState('');
    const hasData = Object.keys(InfoPage).length > 0;

    useEffect(() => {
        axios.get('https://localhost:7172/api/Patient/1')
            .then(response => {
                setInfoPage(response.data);
            })
            .catch(error => {
                console.error("Помилка при отриманні даних:", error);
            });
    }, []);

    const handleEditClick = () => {
        setIsEditing(true);
    };

    const handleCancelClick = () => {
        setIsEditing(false);
    };

    const handleSaveClick = () => {
        axios.post('https://localhost:7172/api/Patient/1', {
            firstName: editedFirstName,
            secondName: editedSecondName,
        })
            .then(response => {
                console.log("Дані успішно збережено:", response.data);
                setIsEditing(false); // Зупиняємо режим редагування
            })
            .catch(error => {
                console.error("Помилка при оновленні даних:", error);
                setIsEditing(false);
            });
    };

    const handleFirstNameChange = (event) => {
        setEditedFirstName(event.target.value);
    };

    const handleSecondNameChange = (event) => {
        setEditedSecondName(event.target.value);
    };

    const handleEmailChange = (event) => {
        setEditedEmail(event.target.value);
    };

    const handleDateChange = (event) => {
        setEditedDate(event.target.value);
    };

    return (
        <div className="body11">
            <img className="img11" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
                <h2 className="h22">{isEditing ? (
                    <input className='inputsmt'
                    placeholder="Ім'я"
                    type="text"
                    name="username"
                    value={editedFirstName}
                    onChange={handleFirstNameChange}
                />
                ) : (
                    InfoPage.firstName 
                )} {isEditing ? (
                    <input className='inputsmt'
                    placeholder="Прізвище"
                    type="text"
                    name="surname"
                    value={editedSecondName}
                    onChange={handleSecondNameChange}
                />
                ) : (
                    InfoPage.secondName
                )}</h2>
                <img className="img22" src={img2}/>
                <img className="img33" src={img3} onClick={handleEditClick}/>
                {isEditing ? (
                    <input className='inputdate'
                    placeholder="День народження"
                    type="date"
                    name="datel"
                    value={editedDate}
                    onChange={handleDateChange}
                />
                ) : (
                    <div className='div22'>
                        <p className='p11'>{InfoPage.birthday}</p>
                        <img className="img44" src={img4} style={{ marginLeft: '240px', marginTop: '-100px' }}/>
                    </div>
                )}
                {isEditing ? (
                    <input className='inputemail'
                    placeholder="Електронна адреса"
                    type="text"
                    name="email"
                    value={editedEmail}
                    onChange={handleEmailChange}
                />
                ) : (
                    <div className='div22'>
                        <p className='p11'>{InfoPage.email}</p>
                        <img className="img44" src={img6} style={{ marginLeft: '240px', marginTop: '-100px' }}/>
                        </div>
                )}
                    {isEditing ? (
                        <></>
                    ) : (
                        <div className='div33'>
                            <p className='p11'>{InfoPage.location}</p>
                            <img className="img44" src={img7} style={{ marginLeft: '240px', marginTop: '-100px' }}/>
                        </div>
                    )}
               
                <div className='div44'>
                    <p className='p11'>{InfoPage.phone}</p>
                    {isEditing ? (
                        <></>
                    ) : (
                        <img className="img44" src={img8} style={{ marginLeft: '240px', marginTop: '-100px' }}/>
                    )}
                </div>
                <div className='div44'>
                    <p className='p11'>{InfoPage.ipn}</p>
                    {isEditing ? (
                        <></>
                    ) : (
                        <img className="img44" src={img9} style={{ marginLeft: '240px', marginTop: '-100px' }}/>
                    )}
                </div>
                {isEditing && (
                <div><button onClick={handleSaveClick}>Зберегти</button>
                <button onClick={handleCancelClick}>Відмінити</button></div>)}
                
            </div>
    );
}

export default Patientprofile;