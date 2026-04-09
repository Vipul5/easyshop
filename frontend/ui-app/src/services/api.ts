const API_BASE = import.meta.env.VITE_API_URL;

export async function getProducts() {
  // const res = await fetch(`/api/products`);
  const res = await fetch(`${API_BASE}/api/products`);

  return res.json();
}