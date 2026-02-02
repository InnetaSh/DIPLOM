import { useState } from "react";
import { Text } from "../Text/Text";

export const CounterButton = () => {
  const [value, setValue] = useState(1);

  const decrement = () => {
    setValue(v => Math.max(1, v - 1));
  };

  const increment = () => {
    setValue(v => v + 1);
  };

  return (
    <div className="btn btn-counter btn-br-r-20">
      <button onClick={decrement}>-</button>
      <Text text={value} type="m_500" />
      <button onClick={increment}>+</button>
    </div>
  );
};
