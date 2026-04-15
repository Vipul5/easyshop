import { useState } from "react";
import { setAuth } from "../services/auth";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleLogin = async () => {

     try {
              const res = await fetch("http://localhost:5091/api/auth/login", {
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
       <br></br>
       <br></br>

       GUID 1:<span>01d1c14c-fdc9-42ac-ab80-ec9f311778d5</span>
    </div>
  );
}