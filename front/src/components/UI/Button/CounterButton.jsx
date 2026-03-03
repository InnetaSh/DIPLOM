import { useState } from "react";
import { Text } from "../Text/Text";

export const CounterButton = ({ value, onChange, min = 0 }) => {

  const decrement = () => {
    const newValue = Math.max(min, value - 1);
    onChange(newValue);
  };

  const increment = () => {
    onChange(value + 1);
  };

  return (
    <div className="btn btn-counter btn-br-r-20">
      <button onClick={decrement}>-</button>
      <Text text={value} type="m_500" />
      <button onClick={increment}>+</button>
    </div>
  );
};
