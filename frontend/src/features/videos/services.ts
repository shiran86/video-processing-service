import type { Video } from './components/videoView/types'

export const getVideo = async (id: number): Promise<Video> => {
  const response = await fetch(`https://localhost:7105/api/v1/videos/${id}`, { credentials: 'include' })

  if (!response.ok) {
    throw new Error(`Request failed with status ${response.status}`)
  }

  return response.json() as Promise<Video>
}
