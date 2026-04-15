const BASE_URL = "http://localhost:5171/api/products";

export const getProducts = async () => {
  const res = await fetch(BASE_URL);
  return res.json();
};

export const searchProducts = async (query: string) => {
  const res = await fetch(`${BASE_URL}/search?query=${query}`);
  return res.json();
};

export const getByCategory = async (categoryId: number) => {
  const res = await fetch(`${BASE_URL}/category/${categoryId}`);
  return res.json();
};

export const getProductById = async (id: number) => {
  const res = await fetch(`${BASE_URL}/${id}`);
  return res.json();
};