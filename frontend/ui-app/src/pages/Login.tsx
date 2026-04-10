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

      <p>
              <br></br>


        New user? <Link to="/register">Register</Link>
      </p>
    </div>
  );
}