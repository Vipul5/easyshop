import { useState } from "react";
import { login } from "../services/authService";
import { useNavigate, Link } from "react-router-dom";

export default function Login() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const res = await login(email, password);

      localStorage.setItem("token", res.token);

      navigate("/products");
    } catch {
      alert("Invalid credentials");
    }
  };

  return (
    <div>
      <h2>Login</h2>

      <input placeholder="Email" onChange={(e) => setEmail(e.target.value)} />
      <br></br>
      <input placeholder="Password" type="password" onChange={(e) => setPassword(e.target.value)} />
      <br></br>

      <button onClick={handleLogin}>Login</button>
      <br></br>   
      <p>
        New user? <Link to="/register">Register</Link>
      </p>
       <br></br>
      GUID: 4 <span>46e49b0e-6153-4e67-8f79-fc5b0020f547</span>
    </div>
  );
}