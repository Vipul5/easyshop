import { useEffect, useState } from "react";
import { getProducts } from "../src/services/api";
import type { Product } from "../src/types/product";

export default function ProductList() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    getProducts().then(setProducts);
  }, []);

  return (
    <div>
      <h1>Welcome to EasyShop</h1>
      <h2>Products</h2>
      {products.map(p => (
        <div key={p.id}>
          {p.name} - ₹{p.price}
        </div>
      ))}
    </div>
  );
}