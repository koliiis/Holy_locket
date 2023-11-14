import React, { useState, useEffect } from 'react';
import './modal-appointment.css'
function Modal_Appointment({active, setActive}) {

    return (
        <div className={active ? "modal active" : "modal"} onClick={() => setActive(true)}>
            <div className={active ? "modal_content active" : "modal_content"} onClick={e => e.stopPropagation()}>
                <p>shakalaka</p>
            </div>
        </div>
    );
}

export default Modal_Appointment;
