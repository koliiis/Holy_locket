import React, { useState, useEffect } from 'react';
import './modal-appointment.css'
function Modal_Appointment(active, setActive) {

    return (
        <div className={active ? "model active" : "modal"} onClick={() => setActive(false)}>
            <div className={active ? "modal_content active" : "modal_content"} onClick={e => e.stopImmediatePropagation()}>

            </div>
        </div>
    );
}

export default Modal_Appointment;
