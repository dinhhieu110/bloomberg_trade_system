import React, { FC } from "react";

type IFavoriteStockCardProps = {
  stock: string;
};

const FavoriteStockCard: FC<IFavoriteStockCardProps> = (props) => {
  const { stock } = props;
  return (
    <>
      <h4>{stock}</h4>
      <button>X</button>
    </>
  );
};

export default FavoriteStockCard;
