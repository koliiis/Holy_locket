import React, { useState } from 'react';
import './Registration.css';
import axios from "axios";
import Modal_Appointment from "../../component/modal-appointment";

function Registration() {
    const [modalSuccessActive, setModalSuccessActive] = useState(false);
    const [modalErrorActive, setModalErrorActive] = useState(false);
    const [name, setName] = useState('');
    const [surname, setSurname] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const [nameError, setNameError] = useState('');

    const validateEmail = (email) => {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(email);
      };

    const handleSubmit = (e) => {
        e.preventDefault();

        let hasErrors = false;
        let hasResponse = false;

        if (name.length < 2 || name.length > 15) {
            setNameError('Неправильно введено ім`я');
            hasErrors = true;
        } else if (surname.length < 7 || surname.length > 20) {
            setNameError('Неправильно введено прізвище');
            hasErrors = true;
        } else if (phoneNumber.length < 6) {
            setNameError('Неправильно введено телефон');
            hasErrors = true;
        } else if (!validateEmail(email)) {
            setNameError('Неправильно введений email');
            hasErrors = true;
        } else if (password.length < 5) {
            setNameError('Пароль має бути як мінімум 6 знаків!');
            hasErrors = true;
        } else {
            setNameError('');
            hasResponse = true;
        }

          if (hasErrors) {
            setModalErrorActive(true);
            return;
          }

          if (hasResponse) {
            setModalSuccessActive(true);
            return;
          }

        axios.post('https://localhost:7172/api/Patient', {
            firstName: name,
            secondName: surname,
            phone: phoneNumber,
            email: email,
            password: password,
        })

            .then((response) => {
                console.log("Peremoga");
                setModalSuccessActive(true);
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
                        />
                        <br />

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
                        <button className='button_left' type="submit" >Зареєструватися</button>
                        <button className='button_right' type="reset">Уже маю аккаунт</button>
                    </div>
                </div>
            </form>

            {/* Модальное окно для успешной регистрации */}
            {modalSuccessActive && (
        <Modal_Appointment
          active={modalSuccessActive}
          setActive={() => setModalSuccessActive(false)}
        >
            <div>
                <div>
          <h3 className='suc'>Успішна реєстрація!!</h3>
          </div>
          
          <div>
            <p>
          <form action="#" method="POST"  onSubmit={handleSubmit}>
                                <button className="confirm" type="submit" onClick={() => setModalSuccessActive(false)}>Підтвердити</button>
                            </form>
                            </p>
                            </div>
                            </div>
        </Modal_Appointment>
      )}

      {/* Модальное окно с ошибками ввода */}
      {modalErrorActive && (
        <Modal_Appointment
          active={modalErrorActive}
          setActive={() => setModalErrorActive(false)}
        >
            <div>
                <div>
          <h3>При заповненні форми виникли помилки:</h3>
          <ul className='qwe'>
            {nameError && <li>{nameError}</li>}
            {/* Добавьте аналогичные строки для других ошибок */}
          </ul>
          </div>
          
          <div>
            <p>
          <form action="#" method="POST"  onSubmit={handleSubmit}>
                                <button className="confirm" type="submit" onClick={() => setModalErrorActive(false)}>Підтвердити</button>
                            </form>
                            </p>
                            </div>
                            </div>
        </Modal_Appointment>
      )}
        </div>
    );
}

export default Registration;