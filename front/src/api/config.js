let config = null;

export const loadConfig = async () => {
  if (!config) {
    const res = await fetch("/config.json");
    config = await res.json();
  }
  return config;
};

export const getConfig = () => {
  if (!config) throw new Error("Config not loaded yet!");
  return config;
};