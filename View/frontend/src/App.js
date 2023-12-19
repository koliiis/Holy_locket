import { Routes, Route } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import Registration from './pages/registration/Registration';
import Appointment from "./pages/appointment/appointment";
import Doctor from "./pages/doctors/doctors";
import Landing from "./pages/landing/landing";
import NavBar from "./component/NavBar";
import Patientsappointments from "./pages/patientsappointments/patientsappointments";
import Patientprofile from "./pages/patientprofile/patientprofile";
import Login from "./pages/login/Login";

const App = () => {
  return (
      <div className="App">
        <nav>
            <NavBar />
        </nav>
        <main>
            <Routes>
                <Route path="/registration" element={<Registration />} />
                <Route path="/appointment" element={<Appointment />} />
                <Route path="/doctors" element={<Doctor />} />
                <Route path="/" element={<Landing />} />
                <Route path="/landing" element={<Landing />} />
                <Route path="/patientsappointments" element={<Patientsappointments />} />
                <Route path="/patientprofile" element={<Patientprofile />} />
                <Route path="/login" element={<Login />} />
            </Routes>
        </main>
      </div>
  );
}

export default App;
