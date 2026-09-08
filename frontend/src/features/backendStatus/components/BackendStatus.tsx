import { useState } from "react";
import { checkBackend } from "../services";

const BackendStatus = () => {
    const [status, setStatus] = useState<string>("Not checked");
    const [isLoading, setIsLoading] = useState<boolean>(false);

    async function handleCheckBackend(): Promise<void> {
        setIsLoading(true);

        try {
            const data = await checkBackend();

            setStatus(data.status);
        } catch {
            setStatus("Backend unavailable");
        } finally {
            setIsLoading(false);
        }
    }

    return (
        <div>
            <button onClick={handleCheckBackend} disabled={isLoading}>
                {isLoading ? "Checking..." : "Check Backend"}
            </button>

            <p>Backend status: {status}</p>
        </div>
    );
}

export default BackendStatus;