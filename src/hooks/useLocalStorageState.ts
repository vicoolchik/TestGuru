import { useState, useEffect } from "react";

// T is a generic type for the state
export function useLocalStorageState<T>(key: string, initialState: T) {
  const [value, setValue] = useState<T>(() => {
    const storedValue = localStorage.getItem(key);
    return storedValue !== null ? JSON.parse(storedValue) : initialState;
  });

  useEffect(() => {
    localStorage.setItem(key, JSON.stringify(value));
  }, [value, key]);

  return [value, setValue] as const; // Ensuring the return type is readonly tuple [T, Dispatch<SetStateAction<T>>]
}
