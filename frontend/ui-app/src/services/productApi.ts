
const PRODUCT_URL = `${import.meta.env.VITE_PRODUCT_URL}/products`;

export const getProducts = async () => {
  const res = await fetch(PRODUCT_URL);
  return res.json();
};

export const searchProducts = async (query: string) => {
  const res = await fetch(`${PRODUCT_URL}/search?query=${query}`);
  return res.json();
};

export const getByCategory = async (categoryId: number) => {
  const res = await fetch(`${PRODUCT_URL}/category/${categoryId}`);
  return res.json();
};

export const getProductById = async (id: number) => {
  const res = await fetch(`${PRODUCT_URL}/${id}`);
  return res.json();
};