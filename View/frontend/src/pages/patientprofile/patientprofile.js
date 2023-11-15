import React, { useState, useEffect } from 'react';
import "./patientprofile.css";
import { useNavigate } from 'react-router-dom';

import img2 from './img2.png';
import img3 from './img3.png';
import img4 from './img4.png';
import img5 from './img5.png';
import img6 from './img6.png';
import img7 from './img7.png';
import img8 from './img8.png';
import img9 from './img9.png';

function Patientprofile() {
    const navigate = useNavigate();

    return (
    <div className="body1">
        <img className="img1" src="https://ggclinic.com.ua/wp-content/uploads/2022/06/doctor-full.jpeg"/>
        <h2 className="h2">Костя Пивопив</h2> 
        <img className="img2" src={img2}/>
        <img className="img3" src={img3}/>
        <div className='div1'><p className='p1'>Чоловік</p><img className="img5" src={img5}/></div>
        <div className='div2'><p className='p1'>03.11.2004</p><img className="img4" src={img4}/></div>
        <div className='div2'><p className='p1'>yaloh@gmail.com</p><img className="img4" src={img6}/></div>
        <div className='div3'><p className='p1'>Україна, Київ</p><img className="img4" src={img7}/></div>
        <div className='div4'><p className='p1'>+38(038)038-03-80</p><img className="img5" src={img8}/></div>
        <div className='div4'><p className='p1'>1234567890</p><img className="img5" src={img9}/></div>
    </div>
   );
}

export default Patientprofile;