import { useState } from "react";
import { setAuth } from "../services/auth";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

const AUTH_URL = `${import.meta.env.VITE_AUTH_URL}/auth`;

  const handleLogin = async () => {

     try {
              const res = await fetch(`${AUTH_URL}/login`, {
            method: "POST",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify({ username, password }),
          });

          const data = await res.json();

          if (data) {
            setAuth(data);
            navigate("/"); // 🔥 go back to home
          }
        } catch (error: any) {
          alert("Invalid Credentials");
        }

   
  };

  return (
    <div>
      <h2>Login</h2>

      <input
        placeholder="Username"
        onChange={(e) => setUsername(e.target.value)}
      />
<br></br>
      <input
        type="password"
        placeholder="Password"
        onChange={(e) => setPassword(e.target.value)}
      />
      <br></br>
      <button onClick={handleLogin}>Login</button>
      <br></br>
      <br></br>
      <p>
           New user? <button onClick={() => navigate("/register")}>Register</button>
       </p>
      
    </div>
  );
}