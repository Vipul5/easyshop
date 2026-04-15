import { addToCart } from "../services/cartApi";
import { getAuth, isLoggedIn } from "../services/auth";

type Props = {
  product: any;
};

const user = getAuth();


export default function ProductCard({ product }: Props) {
  const handleAdd = () => {
    addToCart({
       userId: user?.userId,
      productId: product.id,
      quantity: 1,
    });
  };

  return (
    <div style={{
      border: "1px solid #ccc",
      padding: "10px",
      width: "200px",
      display: "flex",
      flexDirection: "column",
      justifyContent: "space-between",
      height: "300px"
    }}>
      {/* Top content */}
      <div>
        <img src={product.image} width={150} />
        <br></br>
        <span><b>{product.name}</b></span>
      </div>

      {/* Bottom content */}
      <div style={{ marginBottom: "2px" }}>
        <p><b>₹ {product.price}</b></p>

        {isLoggedIn() && (
          <button onClick={handleAdd}>
            Add to Cart
          </button>
        )}
      </div>
    </div>
  );
}