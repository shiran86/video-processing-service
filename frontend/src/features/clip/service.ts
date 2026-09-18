import type { CreateClipRequest } from './types'

export const createClip = async (
  videoId: number,
  request: CreateClipRequest
) => {
  const response = await fetch(
    `/api/v1/videos/${videoId}/clips`,
    {
      method: 'POST',
      credentials: 'include',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(request),
    }
  )

  if (!response.ok) {
    throw new Error('Failed to create clips')
  }

  return response.json()
}