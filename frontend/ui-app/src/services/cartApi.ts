const CART_URL = `${import.meta.env.VITE_CART_URL}/cart`;

export const addToCart = async (data: any) => {
  await fetch(`${CART_URL}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  });
};

export const getCart = async (userId: number) => {
  const res = await fetch(`${CART_URL}/${userId}`);
  return res.json();
};

export const removeFromCart = async (id: number) => {
   await fetch(`${CART_URL}/${id}`, {
    method: "DELETE",
  });
};