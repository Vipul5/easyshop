import { useState } from "react";
import { register } from "../services/authService";
import { useNavigate } from "react-router-dom";

export default function Register() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleRegister = async () => {
    await register(email, password);
    alert("Registered successfully");
    navigate("/");
  };

  return (
    <div>
      <h2>Register</h2>

      <input placeholder="Email" onChange={(e) => setEmail(e.target.value)} />
      <br></br>

      <input placeholder="Password" type="password" onChange={(e) => setPassword(e.target.value)} />
      <br></br>

      <button onClick={handleRegister}>Register</button>
    </div>
  );
}