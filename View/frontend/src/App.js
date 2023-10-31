import { Routes, Route } from 'react-router-dom';
import Registration from './pages/registration/Registration';
import Appointment from "./pages/appointment/appointment";
import Doctor from "./pages/doctors/doctors";
import NavBar from "./component/NavBar";


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
                <Route path="/doctors" element={<Doctor/>} />
            </Routes>
        </main>
      </div>
  );
}

export default App;
