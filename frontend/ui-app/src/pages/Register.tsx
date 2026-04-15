import { useState } from "react";
import { register } from "../services/authService";
import { useNavigate } from "react-router-dom";

export default function Register() {
  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleRegister = async () => {
    try {
      await register(userName, password);
      alert("Registered successfully");
      navigate("/");
    } catch (error: any) {
      alert(error.response.data || error?.message  || "Registration failed");
    }
  };

  return (
    <div>
      <h2>Register</h2>

      <input placeholder="User Name" onChange={(e) => setUserName(e.target.value)} />
      <br></br>

      <input placeholder="Password" type="password" onChange={(e) => setPassword(e.target.value)} />
      <br></br>

      <button onClick={handleRegister}>Register</button>
    </div>
  );
}