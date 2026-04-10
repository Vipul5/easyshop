import { useEffect, useState, type SetStateAction } from "react";
import API from "../services/api";

export default function Products() {
  const [products, setProducts] = useState<any[]>([]);

  useEffect(() => {
    API.get("/products")
      .then((res: { data: SetStateAction<any[]>; }) => setProducts(res.data))
      .catch(() => alert("Unauthorized"));
  }, []);

  const logout = () => {
    localStorage.removeItem("token");
    window.location.href = "/";
  };

  return (
    <div>
      <h2>Products</h2>
      <button onClick={logout}>Logout</button>

      {products.map((p) => (
        <div key={p.id}>
          {p.name} - {p.price}
        </div>
      ))}
      <br></br>
      GUID: 3 <span>c3d15457-2168-440c-a919-590a6f195b30</span>
    </div>
    
  );
}