import { ClipEditor } from '../features/clip/ClipEditor'
import { VideoPlayer } from '../features/videos/components/videoPlayer/VideoPlayer'
import { useVideo } from '../features/videos/useVideo'
import type { CreateClipSegmentRequest } from '../features/clip/types'
import { useCreateClip } from '../features/clip/useCreateClip'

const VIDEO_ID = 123

export const VideoPage = () => {
  const { data: video, isLoading, error } = useVideo(VIDEO_ID)
  const createClipMutation = useCreateClip()

  const handleUpload = (segments: CreateClipSegmentRequest[]) => {
    createClipMutation.mutate({
      videoId: VIDEO_ID,
      request: {
        segments,
      },
    })
  }

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

      <ClipEditor onUpload={handleUpload} />
    </div>
  )
}
