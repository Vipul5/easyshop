import { useEffect, useState } from "react";
import ProductCard from "../components/ProductCard";
import { getProducts, searchProducts, getByCategory } from "../services/productApi";

export default function Home() {
  const [products, setProducts] = useState<any[]>([]);
  const [query, setQuery] = useState("");

  useEffect(() => {
    loadProducts();
  }, []);

  const loadProducts = async () => {
    const data = await getProducts();
    setProducts(data);
  };

  const handleSearch = async () => {
    const data = await searchProducts(query);
    setProducts(data);
  };

  const handleCategory = async (categoryId: number) => {
    const data = await getByCategory(categoryId);
    setProducts(data);
  };

  return (
    <div>

      {/*  Search */}
     <div style={{ padding: "10px", display: "flex", gap: "10px" }}>
        <input
          type="text"
          placeholder="Search products..."
          value={query}
          onChange={(e) => setQuery(e.target.value)}
        />
        <button onClick={handleSearch}>Search</button>
      </div>

      {/*  Category */}
    <div style={{ padding: "10px", display: "flex", gap: "10px" }}>
        <button onClick={() => loadProducts()}>All</button>
        <button onClick={() => handleCategory(1)}>Electronics</button>
        <button onClick={() => handleCategory(2)}>Apparel</button>
      </div>

      {/* Products */}
      <div style={{
        display: "flex",
        flexWrap: "wrap",
        gap: "10px",
        padding: "10px",
      }}>
        {products.map(p => (
          <ProductCard key={p.productId} product={p} />
        ))}
      </div>

       <br></br>
       <br></br>

       GUID 5:<span>2b97434b-c7d5-4f2c-ab66-f2a5c6289516</span>
    </div>
  );
}