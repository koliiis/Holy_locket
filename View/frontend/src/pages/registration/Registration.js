import React, { useState } from 'react';
import './Registration.css';
import axios from "axios";
import Modal_Registration from "../../component/modal-registration";

function Registration() {
    const [modalActive, setModalActive] = useState(false);
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        axios.post('https://localhost:7172/api/Patient', {
            firstName: name,
            secondName: surname,
            phone: phoneNumber,
            email: email,
            password: password,
        })

            .then((response) => {
                console.log("Peremoga");
            })
            .catch((error) => {
                console.error('Ошибка при отправке данных:', error);
            });
    }

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

                        <input
                            placeholder="Ваш пароль"
                            type="password"
                            name="user_password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                        /><br />

                    </div>
                    <div className="button">
                        <button className='button_left' type="submit" onClick={() => setModalActive(true)}>Зареєструватися</button>
                        <button className='button_right' type="reset">Уже маю аккаунт</button>
                    </div>
                </div>
            </form>
            {modalActive && (
                <Modal_Registration
                    active={modalActive}
                    setActive={() => setModalActive(false)}>
                    <h3>
                        <p>
                            Реєстрація успішна!!
                        </p>
                        <div>
                            <form action="#" method="POST"  onSubmit={handleSubmit}>
                                <button className="confirm" type="submit" onClick={() => setModalActive(false)}>Підтвердити</button>
                            </form>
                        </div>
                    </h3>
                </Modal_Registration>
            )}
        </div>
    );
}

export default Registration;