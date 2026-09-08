const API_BASE_URL: string = "http://localhost:8000";

export async function checkBackend(): Promise<{ status: string }> {
    const response: Response = await fetch(`${API_BASE_URL}/health`);

    if (!response.ok) {
        throw new Error(`Backend request failed: ${response.status}`);
    }

    const data: { status: string } = await response.json();

    return data;
}