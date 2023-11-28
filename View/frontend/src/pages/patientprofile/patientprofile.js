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
        axios.put('https://localhost:7172/api/Patient', {
            id: 1,
            firstName: editedFirstName,
            secondName: InfoPage.secondName,
            phone: InfoPage.phone,
            email: InfoPage.email,
            password: InfoPage.password,
            birthday: InfoPage.birthday,
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

    return (
        <div className="body11">
            <img className="img11" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
                <h2 className="h22">{isEditing ? (
                    <input
                    placeholder="Ім'я"
                    type="text"
                    name="username"
                    value={editedFirstName}
                    onChange={handleFirstNameChange}
                />
                ) : (
                    InfoPage.firstName
                )} {InfoPage.secondName}</h2>
                <img className="img22" src={img2}/>
                <img className="img33" src={img3} onClick={handleEditClick}/>
                <div className='div11'>
                    <p className='p11'></p>
                    {hasData ? (
                        <img className="img44" src={img5}/>
                    ) : (
                        <img className="img44" src={img5} style={{ marginLeft: '240px', marginTop: '-5px' }}/>
                    )}
                </div>
                <div className='div22'>
                    <p className='p11'>{InfoPage.birthday}</p>
                    {hasData ? (
                        <img className="img44" src={img4}/>
                    ) : (
                        <img className="img44" src={img4} style={{ marginLeft: '240px', marginTop: '-5px' }}/>
                    )}
                </div>
                <div className='div22'>
                    <p className='p11'>{InfoPage.email}</p>
                    {hasData ? (
                        <img className="img44" src={img6}/>
                    ) : (
                        <img className="img44" src={img6} style={{ marginLeft: '240px', marginTop: '-5px' }}/>
                    )}
                </div>
                <div className='div33'>
                    <p className='p11'></p>
                    {hasData ? (
                        <img className="img44" src={img7}/>
                    ) : (
                        <img className="img44" src={img7} style={{ marginLeft: '240px', marginTop: '-5px' }}/>
                    )}
                </div>
                <div className='div44'>
                    <p className='p11'>{InfoPage.phone}</p>
                    {hasData ? (
                        <img className="img44" src={img8}/>
                    ) : (
                        <img className="img44" src={img8} style={{ marginLeft: '240px', marginTop: '-5px' }}/>
                    )}
                </div>
                <div className='div44'>
                    <p className='p11'></p>
                    {hasData ? (
                        <img className="img44" src={img9}/>
                    ) : (
                        <img className="img44" src={img9} style={{ marginLeft: '240px', marginTop: '-5px' }}/>
                    )}
                </div>
                {isEditing && (
                <div><button onClick={handleSaveClick}>Зберегти</button>
                <button onClick={handleCancelClick}>Відмінити</button></div>)}
                
            </div>
    );
}

export default Patientprofile;