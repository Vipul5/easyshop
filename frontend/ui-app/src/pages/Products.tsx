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
      GUID: <span>6ec85706-1fcf-477b-8d6c-8e4041bd7e58</span>
    </div>

    
  );
}