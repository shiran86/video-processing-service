import { useState } from 'react'
import { Clips } from '../features/clip/clips/Clips'
import { VideoPlayer } from '../features/videos/components/videoPlayer/VideoPlayer'
import { useVideo } from '../features/videos/useVideo'
import type { CreateClipSegmentRequest } from '../features/clip/types'
import { useCreateClip } from '../features/clip/useCreateClip'

const VIDEO_ID = 123

export const VideoPage = () => {
  const { data: video, isLoading, error } = useVideo(VIDEO_ID);
  const createClipMutation = useCreateClip();

  const [clips] = useState<CreateClipSegmentRequest[]>([
    { startTime: 2, endTime: 3 },
    { startTime: 7, endTime: 8 },
  ])

  if (isLoading) {
    return <div>Loading...</div>
  }

  if (error) {
    return <div>Unable to load the video: {error.message}</div>
  }

  if (!video) {
    return <div>Video not found.</div>
  }

  return (
    <div>
      <h1>{video.name}</h1>

      <VideoPlayer
        src={video.preSignedUrl}
        controls
      />

      <Clips clips={clips} onUpload={createClipMutation.mutate} />
    </div>
  )
}
