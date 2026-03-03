import {Text} from "./Text/Text.jsx"

export const Spinner = ({ loading }) => {


  if (!loading) return null;

  return (
    <div className="spinner-wrapper flex-center btn-w-full btn-h-full">
      <div className="spinner" />
      <Text text="Loading..." type ="m_500_s_36"/>
    </div>
  );
};
