import React, { useState } from 'react';
import './Registration.css';

function Registration() {
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [email, setEmail] = useState('');
    const [registrationData, setRegistrationData] = useState(null);
    const handleSubmit = (e) => {
        e.preventDefault();

        const data = {
            name,
            surname,
            phoneNumber,
            email,
        };
        setRegistrationData(data);
    };


    return (
        <div className="master">
            <form action="#" method="POST"  onSubmit={handleSubmit}>
                <div className="master_2">
                    <h2 className="header">Реєстрація</h2>
                    <div className="input">
                        <input
                            placeholder="Ім'я"
                            type="text"
                            name="username"
                            value={name}
                            onChange={(e) => setName(e.target.value)}
                        /><br />

                        <input
                            placeholder="Прізвище"
                            type="text"
                            name="surname"
                            value={surname}
                            onChange={(e) => setSurname(e.target.value)}
                        /><br />

                        <input
                            placeholder="Номер телефону"
                            type="tel"
                            name="usernumber"
                            value={phoneNumber}
                            onChange={(e) => setPhoneNumber(e.target.value)}
                        /><br />

                        <input
                            placeholder="Вам email"
                            type="email"
                            name="useremail"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        /><br />

                    </div>
                    <div className="button">
                        <button className='button_left' type="submit">Зареєструватися</button>
                        <button className='button_right' type="reset">Уже маю аккаунт</button>
                    </div>
                </div>
            </form>
            {registrationData && (
                <div className="registration-data">
                    <h3>Дані реєстрації:</h3>
                    <p>Ім'я: {registrationData.name}</p>
                    <p>Прізвище: {registrationData.surname}</p>
                    <p>Номер телефону: {registrationData.phoneNumber}</p>
                    <p>Email: {registrationData.email}</p>
                </div>
            )}
        </div>
    );
}

export default Registration;
