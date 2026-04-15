import { isLoggedIn, logout } from "../services/auth";
import { useNavigate } from "react-router-dom";

export default function Header() {
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
   window.location.href = "/";  
  };

  const loggedIn = isLoggedIn();   // 🔥 always fresh value

  return (
    <div style={{
      display: "flex",
      justifyContent: "space-between",
      padding: "10px",
      background: "#35704e",
      color: "#fff"
    }}>
      <h2 style={{ cursor: "pointer" }} onClick={() => navigate("/")}>
            EasyShop
       </h2>

      <div style={{ display: "flex", gap: "10px" }}>

        <button onClick={() => navigate("/")}>Home</button>
        
        {!loggedIn ? (
          <button onClick={() => navigate("/login")}>Login</button>
        ) : (
          <>
            <button onClick={() => navigate("/cart")}>Cart</button>
            <button onClick={handleLogout}>Logout</button>
          </>
        )}
      </div>
    </div>
  );
}