import { useEffect, useState } from "react";
import { getCart, removeFromCart } from "../services/cartApi";
import { getProductById } from "../services/productApi";
import { getAuth } from "../services/auth";

export default function Cart() {
  const [items, setItems] = useState<any[]>([]);
  const user = getAuth();

  const loadCart = async () => {
    if (!user?.userId) return;

    const cartItems = await getCart(user.userId);

    // 🔥 Combine cart + product
    const detailedItems = await Promise.all(
      cartItems.map(async (item: any) => {
        const product = await getProductById(item.productId);

        return {
          ...item,
          product
        };
      })
    );

    setItems(detailedItems);
  };

  useEffect(() => {
    loadCart();
  }, []);

  const handleRemove = async (id: number) => {
    await removeFromCart(id);
    loadCart();
  };

    const totalPrice = items.reduce(
      (sum, item) => sum + (item.product.price * item.quantity),
      0
    );

  const totalItems = items.reduce(
    (sum, item) => sum + item.quantity,
    0
  );

  return (
    <div style={{ padding: "20px" }}>
      <h2>My Cart</h2>

      {items.length === 0 && <p>No items in cart</p>}

      {items.map(item => (
        <div key={item.id} style={{
          border: "1px solid #ccc",
          margin: "10px 0",
          padding: "10px",
          display: "flex",
          gap: "15px",
          alignItems: "center"
        }}>
          {/* 🖼 Image */}
          <img src={item.product.image} width={100} />

          {/* 📦 Details */}
          <div style={{ flex: 1 }}>
            <h3>{item.product.name}</h3>
            <p>{item.product.description}</p>
            <p><b>₹ {item.product.price}</b></p>
            <p>Quantity: {item.quantity}</p>
          </div>

          {/* ❌ Remove */}
          <button onClick={() => handleRemove(item.id)}>
            Remove
          </button>
        </div>
      ))}

      {items.length > 0 && (
        <div style={{
          marginTop: "20px",
          padding: "15px",
          borderTop: "2px solid #000"
        }}>
          <h3>Total Items: {totalItems}</h3>
          <h2>Total Price: ₹ {totalPrice}</h2>
        </div>
      )}
      
    </div>

    
  );
}