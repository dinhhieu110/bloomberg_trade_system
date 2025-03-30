import { SyntheticEvent } from "react";

interface Props {
  onRemoveFavoriteStock: (e: SyntheticEvent) => void;
  stock: string;
}

const RemoveFavoriteStock = (props: Props) => {
  const { onRemoveFavoriteStock, stock } = props;
  return (
    <>
      <form onSubmit={onRemoveFavoriteStock}>
        <input hidden value={stock} />
        <button type="submit">x</button>
      </form>
    </>
  );
};

export default RemoveFavoriteStock;
