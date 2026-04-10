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
      GUID: <span>f9e20de7-f407-4955-80db-049d5a459a02</span>
    </div>

    
  );
}