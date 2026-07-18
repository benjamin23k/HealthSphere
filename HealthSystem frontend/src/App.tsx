import { useState } from "react";
import "./App.css";
import PatientsPage from "./pages/PatientsPage";
import DoctorsPage from "./pages/DoctorsPage";
import DepartmentsPage from "./pages/DepartmentsPage";
import InsurancesPage from "./pages/InsurancesPage";
import AppointmentsPage from "./pages/AppointmentsPage";

const tabs = [
  { key: "patients", label: "Patients", component: <PatientsPage /> },
  { key: "doctors", label: "Doctors", component: <DoctorsPage /> },
  { key: "appointments", label: "Appointments", component: <AppointmentsPage /> },
  { key: "departments", label: "Departments", component: <DepartmentsPage /> },
  { key: "insurances", label: "Insurances", component: <InsurancesPage /> },
];

function App() {
  const [active, setActive] = useState(tabs[0].key);

  return (
    <div className="app-shell">
      <header className="app-header">
        <h1>Patient Management System</h1>
        
      </header>

      <nav className="tabs">
        {tabs.map(t => (
          <button
            key={t.key}
            className={t.key === active ? "tab active" : "tab"}
            onClick={() => setActive(t.key)}
          >
            {t.label}
          </button>
        ))}
      </nav>

      <main className="content">
        {tabs.find(t => t.key === active)?.component}
      </main>
    </div>
  );
}

export default App;
