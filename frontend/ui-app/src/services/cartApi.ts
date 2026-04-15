export const addToCart = async (data: any) => {
  await fetch("http://localhost:5290/api/cart", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  });
};

export const getCart = async (userId: number) => {
  const res = await fetch(`http://localhost:5290/api/cart/${userId}`);
  return res.json();
};

export const removeFromCart = async (id: number) => {
   await fetch(`http://localhost:5290/api/cart/${id}`, {
    method: "DELETE",
  });
};