﻿using UnityEngine;

namespace VampireSquid.Common.Utils
{
    public static class RectBounds
    {
        public static Rect RendererBoundsInScreenSpace(Renderer r)
        {
            Debug.Log(r.transform.position);
            // This is the space occupied by the object's visuals
            // in WORLD space.
            Bounds bigBounds = r.bounds;

            Vector3[] screenSpaceCorners = new Vector3[8];

            Camera theCamera = Camera.main;

            // For each of the 8 corners of our renderer's world space bounding box,
            // convert those corners into screen space.
            screenSpaceCorners[0] = theCamera.WorldToScreenPoint(new Vector3(bigBounds.center.x + bigBounds.extents.x,
                bigBounds.center.y + bigBounds.extents.y, bigBounds.center.z + bigBounds.extents.z));
            screenSpaceCorners[1] = theCamera.WorldToScreenPoint(new Vector3(bigBounds.center.x + bigBounds.extents.x,
                bigBounds.center.y + bigBounds.extents.y, bigBounds.center.z - bigBounds.extents.z));
            screenSpaceCorners[2] = theCamera.WorldToScreenPoint(new Vector3(bigBounds.center.x + bigBounds.extents.x,
                bigBounds.center.y - bigBounds.extents.y, bigBounds.center.z + bigBounds.extents.z));
            screenSpaceCorners[3] = theCamera.WorldToScreenPoint(new Vector3(bigBounds.center.x + bigBounds.extents.x,
                bigBounds.center.y - bigBounds.extents.y, bigBounds.center.z - bigBounds.extents.z));
            screenSpaceCorners[4] = theCamera.WorldToScreenPoint(new Vector3(bigBounds.center.x - bigBounds.extents.x,
                bigBounds.center.y + bigBounds.extents.y, bigBounds.center.z + bigBounds.extents.z));
            screenSpaceCorners[5] = theCamera.WorldToScreenPoint(new Vector3(bigBounds.center.x - bigBounds.extents.x,
                bigBounds.center.y + bigBounds.extents.y, bigBounds.center.z - bigBounds.extents.z));
            screenSpaceCorners[6] = theCamera.WorldToScreenPoint(new Vector3(bigBounds.center.x - bigBounds.extents.x,
                bigBounds.center.y - bigBounds.extents.y, bigBounds.center.z + bigBounds.extents.z));
            screenSpaceCorners[7] = theCamera.WorldToScreenPoint(new Vector3(bigBounds.center.x - bigBounds.extents.x,
                bigBounds.center.y - bigBounds.extents.y, bigBounds.center.z - bigBounds.extents.z));

            // Now find the min/max X & Y of these screen space corners.
            float min_x = screenSpaceCorners[0].x;
            float min_y = screenSpaceCorners[0].y;
            float max_x = screenSpaceCorners[0].x;
            float max_y = screenSpaceCorners[0].y;

            for (int i = 1; i < 8; i++)
            {
                if (screenSpaceCorners[i].x < min_x) min_x = screenSpaceCorners[i].x;
                if (screenSpaceCorners[i].y < min_y) min_y = screenSpaceCorners[i].y;
                if (screenSpaceCorners[i].x > max_x) max_x = screenSpaceCorners[i].x;
                if (screenSpaceCorners[i].y > max_y) max_y = screenSpaceCorners[i].y;
            }

            return Rect.MinMaxRect(min_x, min_y, max_x, max_y);
        }
    }
}